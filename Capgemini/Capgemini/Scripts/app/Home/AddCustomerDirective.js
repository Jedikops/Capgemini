(function () {
    'use strict';
    window.app.directive('addCustomer', addCustomer);
    function addCustomer() {
        return {
            templateUrl: '/Scripts/app/Home/templates/addCustomertemplate.html',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope', 'customerService'];
    function controller($scope, customerService)
    {
        var vm = this;
        vm.add = add;
        vm.customer = {};
        vm.errorMessage = null;
        vm.saving = false;

        function add()
        {
            vm.saving = true;
            customerService.addCustomer(vm.customer).success(function () {
                $scope.$close();
            }).error(function (data) {
                vm.errorMessage = data;
            }).finally(function () {
                vm.saving = false;
            });
        }
        
    }
})();