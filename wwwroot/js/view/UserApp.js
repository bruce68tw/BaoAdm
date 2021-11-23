var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'Phone' },
                { data: 'Email' },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
                { targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, false, false, true);
                }},
            ],
        };

        //initial
		_crud.init(config);
    },

}; //class