var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'Account' },
                { data: 'Status' },
                { data: 'IsAdmin' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [2], render: function (data, type, full, meta) {
                    return _crudR.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crudR.dtYesEmpty(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, false);
                }},
            ],
        };

        //initial
		_crudR.init(config);
    },

}; //class