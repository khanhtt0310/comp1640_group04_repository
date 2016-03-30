cmsApp.directive('dlEnterKey', function() {
    return function(scope, element, attrs) {
        element.bind("Keydown Keypress", function(event) {
            var keyCode = event.which || event.keyCode;

            // if enter key is pressed
            if (keyCode === 13) {
                scope.$apply(function() {
                    scope.$eval(attrs.dlEnterKey);
                });

                event.preventDefault();
            }
        });
    };
});