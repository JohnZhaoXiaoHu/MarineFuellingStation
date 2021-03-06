﻿import ComponentBase from "../../ComponentBase";
import { Component } from 'vue-property-decorator';
import axios from "axios";
import moment from "moment";

@Component
export default class CheckinComponent extends ComponentBase {
    showSelectTime: boolean = false;
    startDate: string;
    endDate: string;
    type: excel.dataType;

    constructor() {
        super();

        this.startDate = this.formatDate(new Date());
        this.endDate = this.startDate;
        this.type = excel.dataType.未指定;
    }
    
    mounted() {
        this.$emit('setTitle', this.$store.state.username + ' 导出excel');
    };

    exportClientsclick() {
        this.type = excel.dataType.客户;
        this.showSelectTime = true;
    }
    exportOrdersclick() {
        this.type = excel.dataType.销售单;
        this.showSelectTime = true;
    }
    exportStoresclick() {
        this.type = excel.dataType.油仓;
        this.showSelectTime = true;
    }
    exportMoveStoresclick() {
        this.type = excel.dataType.转仓单;
        this.showSelectTime = true;
    }
    exportInAndOutLogsclick() {
        this.type = excel.dataType.出入仓记录;
        this.showSelectTime = true;
    }
    exportSurveysclick() {
        this.type = excel.dataType.油仓测量;
        this.showSelectTime = true;
    }
    exportBoatCleansclick() {
        this.type = excel.dataType.船舶清污;
        this.showSelectTime = true;
    }
    exportAssaysclick() {
        this.type = excel.dataType.化验单;
        this.showSelectTime = true;
    }

    submitclick() {
        this.getExport();
    }

    isPreventSubmmit() {
        let start = parseInt(moment(this.startDate).format("YYYYMMDD"));
        let end = parseInt(moment(this.endDate).format("YYYYMMDD"));
        return end < start;
    }

    getExport() {
        let url;
        switch (this.type) {
            case excel.dataType.客户:
                url = "/api/Client/ExportExcel";
                break;
            case excel.dataType.销售单:
                url = "/api/Order/ExportExcel";
                break;
            case excel.dataType.油仓:
                url = "/api/Store/ExportExcel";
                break;
            case excel.dataType.转仓单:
                url = "/api/MoveStore/ExportExcel";
                break;
            case excel.dataType.出入仓记录:
                url = "/api/InAndOutLog/ExportExcel";
                break;
            case excel.dataType.油仓测量:
                url = "/api/Survey/ExportExcel";
                break;
            case excel.dataType.船舶清污:
                url = "/api/BoatClean/ExportExcel";
                break;
            case excel.dataType.化验单:
                url = "/api/Assay/ExportExcel";
                break;
        }
        axios.get(url
            + "?start=" + this.startDate + " 00:00:00"
            + "&end=" + this.endDate + " 23:59:59"
        ).then((res) => {
            let jobj = res.data as server.resultJSON<string>;
            if (jobj.code == 0) {
                this.$dialog.confirm({
                    title: '下载',
                    mes: '是否需要下载该文件？',
                    opts: () => {
                        window.location.href = jobj.data;
                    }
                })
            }   
            else
                this.toastError(jobj.msg)
        });
    }
    
}