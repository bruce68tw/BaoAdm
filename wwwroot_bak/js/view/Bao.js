var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'StartTime' },
                { data: 'EndTime' },
                { data: 'IsMove' },
                { data: 'ReplyTypeName' },
                { data: 'PrizeTypeName' },
                { data: 'PrizeNote' },
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
                    return _crudR.dtYesEmpty(data);
                }},
				{ targets: [8], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, false, true);
                }},
            ],
        };

        //initial
        _crudR.init(config);
    },

}; //class