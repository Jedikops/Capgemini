(function () {
    window.app.factory('customerService', customerService);

    customerService.$inject = ['$http'];
    function customerService($http) {
        var customers = [];
        var error;
        var url = "/api/customers";

        (function loadCustomers() {
            get(10, 1).success(function (data) {
                customers.addRange(customerService.customers);
            });
        })();

        var service = {
            updateCustomer: update,
            getCustomer: getById,
            getCustomers: get,
            addCustomer: add,
            removeCustomer: remove,
            customers: customers

        };

        return service;

        function getById(id)
        {
            return $http.get('/api/customers/' + id);
        }

        function get(count, page) {
            return $http.get('/api/customers').success(function (data) {
                customers.addRange(data);
            });
        }

        function add(customer) {
            return $http.post(url, customer).success(function (customer) {
                customers.unshift(customer);
            });
        }

        function update(updatedCustomer, extendedCustomer)
        {
            return $http.put(url, updatedCustomer).success(function (customer) {
                angular.extend(extendedCustomer, customer);
            });
        }

        function remove(id)
        {
            return $http.delete('/api/customers/' + id).success(function (id) {
                var index = customers.map(function(x){ return x.Id; }).indexOf(id);
                
                customers.splice(index, 1);
            });
        }
    }
})();