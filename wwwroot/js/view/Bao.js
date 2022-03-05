var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'StartTime' },
                { data: 'EndTime' },
                { data: 'IsBatch' },
                { data: 'IsMove' },
                { data: 'IsMoney' },
                { data: 'GiftName' },
                { data: 'StageCount' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [2], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crud.dtYesEmpty(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtYesEmpty(data);
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _crud.dtYesEmpty(data);
                }},
				{ targets: [8], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, false, true);
                }},
            ],
        };

        //initial
        _crud.init(config);
    },

}; //class