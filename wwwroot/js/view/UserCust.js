var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Account' },
                { data: 'Name' },
                { data: 'Phone' },
                { data: 'Email' },
                { data: 'IsCorp' },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [4], render: function (data, type, full, meta) {
                    return data == 1 ? '是' : '';
                }},
				{ targets: [6], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, false);
                }},
            ],
        };

        //initial
		_crudR.init(config);
    },

}; //class