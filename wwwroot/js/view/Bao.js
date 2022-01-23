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
                { data: 'GiftType' },
                { data: 'GiftName' },
                { data: 'StageCount' },
                //{ data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [2], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return (data == '1') ? '是' : '';
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return (data == '1') ? '是' : '';
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return (data == 'G') ? '獎品' :
                        (data == 'M') ? '獎金' :
                        '' ;
                }},
                /*
				{ targets: [8], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
                */
            ],
        };

        //initial
        _crud.init(config);
    },

}; //class