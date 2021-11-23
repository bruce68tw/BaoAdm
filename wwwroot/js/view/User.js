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
                    return _crud.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crud.dtYesEmpty(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, false);
                }},
            ],
        };

        //initial
		_crud.init(config);
    },

}; //class