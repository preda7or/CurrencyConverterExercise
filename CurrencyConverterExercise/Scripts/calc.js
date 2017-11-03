"use strict";

class MyFields {
  constructor() {
    this.$updateBtn = $("#updateBtn");
    this.$fromCurrency = $("#fromCurrency");
    this.$toCurrency = $("#toCurrency");
    this.$fromAmount = $("#fromAmount");
    this.$toAmount = $("#toAmount");
  }
  get fromCurrency() {
    return this.$fromCurrency.val();
  }
  get toCurrency() {
    return this.$toCurrency.val();
  }
  get fromAmount() {
    return this.$fromAmount.val();
  }
  set toAmount(v) {
    return this.$toAmount.val(v);
  }
}

// class AppState {
//   static GetState() {
//     return {
//       fromCurrency: $("#fromCurrency").val(),
//       toCurrency: $("#toCurrency").val(),
//       fromAmount: $("#fromAmount").val(),
//     };
//   }
// }

class MyCalculator {
  constructor(_fields) {
    this.fields = _fields;
  }

  UpdateResult(response) {
    setTimeout(() => {
      this.fields.$updateBtn.button("reset");
    }, 200);

    // check state change
    if (
      this.fields.fromCurrency != response.fromCurrency ||
      this.fields.toCurrency != response.toCurrency ||
      this.fields.fromAmount - response.fromAmount != 0
    ) {
      throw `State has change, please update! 
            fc:${this.fields.fromCurrency}-${response.fromCurrency}
            tc:${this.fields.toCurrency}-${response.toCurrency}
            fa:${this.fields.fromAmount - response.fromAmount}`;
    }
    // update field
    if (typeof response.toAmount == "undefined" || isNaN(response.toAmount)) {
      throw "Calculation result is not valid!";
    }
    this.fields.toAmount = response.toAmount.toFixed(7);
  }

  UpdateCalculation() {
    this.fields.$updateBtn.button("loading");
    $.getJSON(
      `/api/calc/${this.fields.fromCurrency}/${this.fields.toCurrency}/${this
        .fields.fromAmount}`
    )
      .then(response => {
        this.UpdateResult(response);
      })
      .catch(error => {
        throw `Currency options update error: ${error}`;
      });
  }
}

class CurrencySelectors {
  constructor(_calculator) {
    this.calculator = _calculator;

    $.getJSON("/api/currencies")
      .then(response => {
        try {
          this.PopulateSelect(response);
        } catch (err) {
          throw `Error at response parsing: ${err}`;
        }
      })
      .catch(error => {
        throw `Currency options load error: ${error}`;
      });
  }

  PopulateSelect(options) {
    if (
      typeof options != "object" ||
      (Array.isArray && !Array.isArray(options))
    ) {
      throw `UpdateSelect argument is not an array: ${typeof options}`;
    }

    let $el = $(".currency-selector select");
    $el.find("[value]").remove();
    $.each(options, function(key, value) {
      $el.append($(`<option value="${value}">${value}</option>`));
    });
    $el.selectpicker("refresh");
    $el.first().selectpicker("val", options[0]);
    $el.last().selectpicker("val", options[1]);
    this.calculator.UpdateCalculation();
  }
}

$(function() {
  let fields = new MyFields();
  let calc = new MyCalculator(fields);
  let csel = new CurrencySelectors(calc);

  $("#updateBtn").on("click", () => calc.UpdateCalculation());
  $("#fromCurrency, #toCurrency, #fromAmount").on("change", () =>
    calc.UpdateCalculation()
  );
  $("#fromAmount").on("input", () => calc.UpdateCalculation());
});
