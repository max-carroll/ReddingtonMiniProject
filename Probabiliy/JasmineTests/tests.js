// tests.js

/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="../Scripts/Custom/Probability.js" />


describe("ProbabilityCalculation Constructor", function () {

    it("ProbA gets Set", function () {

        var calculation = new ProbabilityCalculation(0.5, 0);
        expect(calculation.ProbA).toBe(0.5);

    });

    it("ProbB gets Set", function () {

        var calculation = new ProbabilityCalculation(0, 0.2);
        expect(calculation.ProbB).toBe(0.2);
    });

    
    it("ProbA greater than 1 throws exception", function () {

        expect(function () { var x = new ProbabilityCalculation(1.1, 0); })
            .toThrowError("Probabilities must be <= 1");
    });

    it("ProbB greater than 1 throws exception", function () {

        expect(function () { var x = new ProbabilityCalculation(0, 1.1); })
            .toThrowError("Probabilities must be <= 1");
    });

    it("ProbA less than 0 throws exception", function () {

        expect(function () { var x = new ProbabilityCalculation(-0.1, 0); })
            .toThrowError("Probabilities must be >= 0");
    });

    it("ProbB less than 0 throws exception", function () {

        expect(function () { var x = new ProbabilityCalculation(0, -0.1); })
            .toThrowError("Probabilities must be >= 0");
    });

    it("ProbA set to string throws error", function () {

        expect(function () { var x = new ProbabilityCalculation("AnyString", 0); })
            .toThrowError("Probabilities must be numbers");
    });

    it("ProbB set to string throws error", function () {

        expect(function () { var x = new ProbabilityCalculation( 0.1, "AnyString"); })
            .toThrowError("Probabilities must be numbers");
    });
    



});

describe("ProbabilityCalculation.CombineWith", function () {


    it("SimpleCombineWith", function () {

        var calculation = new ProbabilityCalculation(1, 1);

        var result = calculation.CombinedWith();
        expect(result).toBe(1);
    });

    it("Combining Halves makes a quarter", function () {

        var calculation = new ProbabilityCalculation(0.5, 0.5);

        var result = calculation.CombinedWith();
        expect(result).toBe(0.25);
    });



});


describe("ProbabilityCalculation.Either", function () {


    it("Either 0.5 or 0.5 equals 0.75", function () {

        var calculation = new ProbabilityCalculation(0.5, 0.5);

        var result = calculation.Either();
        expect(result).toBe(0.75);
    });


});



