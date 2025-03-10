export class libDataTable {
    constructor(element, options) {
        this.element = element;
        this.options = this.SetAttributes(options);
    }
    Initials = async function () {

        //Check dupicate push data dupicated.
        if ($.fn.DataTable.isDataTable(this.element)) {
            this.element.DataTable().clear().draw();
            this.element.DataTable().destroy();
        }

        if (this.options.data != null) {
            var oColumns = await this.SetUpColumn();

            //console.log(this.options.buttons);
            //console.log(this.options.buttons.exporting);

            await this.element.DataTable({

                bDestroy: true,
                order: this.options.order,
                searching: this.options.searching,
                paging: this.options.paging,
                scrollCollapse: this.options.scrollCollapes,
                info: this.options.info,
                scrollY: this.options.scrollY,
                scrollX: this.options.scrollX,
                responsive: this.options.responsive,
                autoWidth: this.options.autowidth,
                data: this.options.data,
                columns: oColumns,
                //dom: 'Bfrtip',
                dom: (this.options.buttons === false) ? "frtip" : 'Bfrtip', // Buttons, filter, table, info, pagination
                buttons: this.options.buttons,
                columnDefs: this.options.columnDefs
            });
        }
        else {
            this.element.DataTable({
                //dom: 'frtip', // Buttons, filter, table, info, pagination
                bDestroy: true,
                data: this.options.data,
                responsive: true,
                columnDefs: this.options.columnDefs,
                searching: this.options.searching,
                paging: this.options.paging,
                info: this.options.info,
            });
        }
    }
    SetAttributes = function (options) {
        var result = {
            data: (typeof (options && options.data) === "undefined") ? null : options.data,
            info: (typeof (options && options.info) === "undefined") ? true : options.info,
            paging: (typeof (options && options.paging) === "undefined") ? true : options.paging,
            order: (typeof (options && options.order) === "undefined") ? true : options.order,
            searching: (typeof (options && options.searching) === "undefined") ? true : options.searching,
            scrollCollapes: (typeof (options && options.scrollCollapes) === "undefined") ? false : obj.scrollCollapes,
            scrollX: (typeof (options && options.scrollX) === "undefined") ? false : options.scrollX,
            scrollY: (typeof (options && options.scrollY) === "undefined") ? false : options.scrollY,
            responsive: (typeof (options && options.responsive) === "undefined") ? true : options.responsive,
            autowidth: (typeof (options && options.autowidth) === "undefined") ? true : options.autowidth,
            buttons: (typeof (options && options.buttons) === "undefined") ? false : SetButton({ copy: options.buttons.copy, excel: options.buttons.excel, defaultExcel: options.buttons.defaultExcel }),
            columnDefs: (typeof (options && options.columnDefs) === "undefined") ? false : options.columnDefs
        }
        function SetButton({ copy = false, excel = false, defaultExcel = true }) {
            var returnData = [];
            if (copy) {
                returnData.push({
                    extend: 'copyHtml5',
                    text: '<i class="fas fa-copy"></i> Copy',
                    className: "copy-button shadow-sm"
                });
            }
            if (excel) {
                //console.log(defaultExporting)
                returnData.push({
                    extend: (defaultExcel === true) ? "excelHtml5" : "",
                    text: '<i class="fa-solid fa-file-export"></i> Export excel',
                    className: 'export-button btn btn-success shadow-sm',
                    //action: function (e, dt, button, config) {
                    //    if (exportingUrl !== undefined) {
                    //        var a = document.createElement("a");
                    //        a.href = exportingUrl//'/Export/ExportDeclareData?Invoice=' + $('#ddInvoice option:selected').val();
                    //        a.target = '_blank';
                    //        document.body.appendChild(a);
                    //        a.click();
                    //    }
                    //    else {
                    //        //$.fn.dataTable.ext.buttons.excelHtml5.action.call(this, e, dt, button, config);
                    //        $.fn.dataTable.ext.buttons.excelHtml5.action.call(this, e, dt, button, $.extend({}, config, {
                    //            //title: filename, // Set custom filename for Excel export
                    //            filename: (exportingFilename === undefined) ? "download" : exportingFilename
                    //        }));
                    //    }
                    //}
                });
            }
            return returnData;
        }

        return result;
    }

    SetUpColumn = async function () {
        //typeof (obj.data.length) != "undefined" ? console.log(obj.data[0]) : console.log(obj.data)
        var oColumns = [];
        var columnNames = Object.keys(typeof (this.options.data.length) != "undefined" ? this.options.data[0] : this.options.data)
        if (this.options.columns == undefined) {
            for (let i in columnNames) {

                oColumns.push({
                    data: columnNames[i]
                });
            }
        }
        else {
            $.each(this.options.columns, function (index, value) {
                for (let i in columnNames) {
                    //console.log("i:" + i, "index:" + index, "column:" + value, "columnsName:" + columnNames[value]);
                    if (i == value) {
                        oColumns.push({
                            data: columnNames[value]
                        });
                    }
                }
            });
        }

        return await oColumns;
    }

    GetRowsAll = async function (selectedColumns) {
        //var table = await $('#' + obj.id).DataTable();
        var data = this.element.DataTable().rows().data().toArray();
        var arr = [];
        //console.log(obj.columns);
        //console.log(data);
        if (selectedColumns === undefined) {
            arr = data;
        }
        else {
            await $.each(data, async function () {
                var row = this;
                var data1 = [];
                let i = 0;
                await $.each(row, async function (key, value) {
                    data1.push({ id: key, value: value });
                });
                //console.log(data1);
                await $.each(selectedColumns, async function () {
                    arr.push(data1[this]);
                });
            });
        }

        return await arr;
    }
    //GetRow = async function (rowElement) {
    //    var row = $(rowElement).closest("tr");
    //    var rowData = this.element.DataTable().row(row).data();
    //    return rowData;
    //}
    GetRowsDataByKey = async function (obj) {
        var data = await _libDataTables.GetRows(obj);
        var arr = [];
        //console.log(data);
        await $.each(data, async function () {
            arr.push(this.value);
        });
        //console.log(arr);
        return await arr;
    }
    AppendRow = async function (obj) {
        var oColumns = await _dtTableMethod.SetUpColumn(obj);
        var table = await $('#' + obj.id).DataTable({
            dom: 'frtip',
            "bDestroy": true,
            columns: oColumns
        });
        var arr = [];
        var data = [];
        await $.each(obj.data, async function () {
            data.push(this);
        });
        //console.log(data);
        await $.each(obj.columns, async function () {
            arr.push(data[this]);
        });
        await table.row.add(obj.data).draw();
    }
    UpdateRow = async function ({ find = null, updatingData = null }) {
        var table = await this.element.DataTable();
        var selectedRow = await this.element.find(find).closest("tr");
        console.log(selectedRow);
        await table.row(selectedRow).invalidate().draw();
        await table.row(selectedRow).data(updatingData).draw();
    }
    ClearAll = async function () {
        await this.element.DataTable().clear().draw();
        //await $('#' + tableId).DataTable(null);
        /*$('#' + tableId).DataTable({ data: null });*/
    }
}

//(function ($) {
//    $.fn.libDataTables = function (options) {

//        this.clsLabDataTables = new labDataTables(this, options);
//        if (options !== undefined) this.clsLabDataTables.Initials();

//        return this.clsLabDataTables
//    }

//})(jQuery);