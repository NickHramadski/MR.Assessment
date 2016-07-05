var GridProxy = (function () {
    'use strict';

    function GridProxy(selector) {
        this.selector = selector;
    }

    GridProxy.prototype.dataBind = function (data) {
        var source =
        {
            localdata: data,
            datafields: [
                { name: 'AdId', type: 'number' },
                { name: 'BrandId', type: 'number' },
                { name: 'Name', type: 'string' },
                { name: 'NumPages', type: 'number' },
                { name: 'Position', type: 'string' }
            ],
            datatype: "json",
            sortcolumn: 'Name',
            sortdirection: 'asc'
        };

        var dataAdapter = new $.jqx.dataAdapter(source);

        $(this.selector).jqxGrid(
        {
            width: "100%",
            source: dataAdapter,
            columnsresize: true,
            sortable: true,
            columns: [
                { text: 'ID', datafield: 'AdId', width: 100 },
                { text: 'Brand Name', datafield: 'Name', width: "50%" },
                { text: 'Brand ID', datafield: 'BrandId', width: 100 },
                { text: 'Num Pages', datafield: 'NumPages' },
                { text: 'Position', datafield: 'Position' }
            ]
        });
    };

    return GridProxy;
}());