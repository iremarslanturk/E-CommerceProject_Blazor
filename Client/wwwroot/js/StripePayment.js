redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51NusLvA1ErZTj1ZxY1i67EOImExRQlSYpNT5l1GkEqTgAb2oZJ2frr2dCPSChvDcmRfINkgIhqL4hYCVb4qtJAft00cuR4ESHV');

    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};
