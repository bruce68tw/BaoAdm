
//use jquery validation
var _valid = {

    //error & valid calss same to jquer validate
    errorClass: 'error',
    //validClass: 'valid',

    /**
     * initial jQuery Validation
     * param form {object} form object
     * return {object} validator object
     */
    init: function (form) {
        //remove data first
        form.removeData('validator');

        //config
        var config = {
            ignore: ':hidden:not([data-type=html]),.note-editable.card-block',   //or summernote got error
            errorElement: 'span',
            errorPlacement: function (error, elm) {
                error.insertAfter(_valid._getBox(elm));
                return false;
            }
            /*
            ignore: '',     //xiFile has hidden input need validate
            onclick: false, //checkbox, radio, and select
            unhighlight: function (elm, errorClass, validClass) {
                var me = $(elm);
                me.data('edit', 1);    //註記此欄位有異動
            }
            highlight: function (elm) {
                _valid._getError(elm).addClass(_valid.errorClass);
                return false;
            },
            unhighlight: function (elm) {
                _valid._getError(elm).removeClass(_valid.errorClass);
                return false;
            },
            */
            //errorClass: 'label label-danger',
        };

        return form.validate(config);
    },

    _getBox: function (elm) {
        return $(elm).closest('.xi-box');
    },

    //get error object
    _getError: function (elm) {
        return _valid._getBox(elm).next();
    },

    /**
     * check regular
     * param fids {array} fid string array
     * param msg {string} error message
     * param expr {regular} regular expression
     * return {bool}
    anyRegularsWrong: function (fids, msg, expr) {
        if (fids == null || fids.length == 0)
            return false;

        //var expr = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var find = false;
        for (var i = 0; i < fids.length; i++) {
            var value = $('#' + fids[i]).val();
            if (!expr.test(value)) {
                find = true;
                _input.showError(fids[i], msg);
            }
        }
        return find;
    },
     */

    /**
     * check email 
     * see : http://stackoverflow.com/questions/46155/validate-email-address-in-javascript
     * params
     *   data : email address
     * return : true/false
    anyEmailsWrong: function (fids, msg) {
        var expr = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return _valid.anyRegularsWrong(fids, msg, expr);
    },
     */

    /**
     * check address
     * params
     *   data : address
     * return : true/false
    anyAddressesWrong: function (fids, msg) {
        var expr = /^\d+\w*\s*(?:(?:[\-\/]?\s*)?\d*(?:\s*\d+\/\s*)?\d+)?\s+/;
        return _valid.anyRegularsWrong(fids, msg, expr);
    },
     */

}; //class