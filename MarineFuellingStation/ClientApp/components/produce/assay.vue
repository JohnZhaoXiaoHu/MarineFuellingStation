﻿<template>
    <div id="root">
        <yd-tab :callback="change">
            <yd-tab-panel label="化验录入">
                <yd-cell-group :title="'单号：' + model.name">
                    <yd-cell-item>
                        <yd-radio-group slot="left" v-model="radio2">
                            <yd-radio val="1">油仓化验</yd-radio>
                            <yd-radio val="2">进油化验</yd-radio>
                        </yd-radio-group>
                    </yd-cell-item>

                    <yd-cell-item v-show="show1">
                        <span slot="left">化验油仓：</span>
                        <select slot="right" v-model="selectedStore">
                            <option value="">请选择油仓</option>
                            <option v-for="s in store" :key="s.id" :value="s.id">{{s.name}}</option>
                        </select>
                    </yd-cell-item>

                    <yd-cell-item v-show="!show1" @click.native="showPurchases = true">
                        <span slot="left">进油来源：</span>
                        <span slot="right">{{selectedPName}}</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">视密：</span>
                        <yd-input slot="right" v-model="model.视密" regex="" placeholder="参考值：0.835"></yd-input>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">标密：</span>
                        <yd-input slot="right" v-model="model.标密" regex="" placeholder="请输入标密"></yd-input>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">闭口闪点：</span>
                        <yd-input slot="right" v-model="model.闭口闪点" regex="" placeholder="参考值：>=61℃"></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">油温：</span>
                        <yd-input slot="right" v-model="model.temperature" regex="" placeholder="请输入油温"></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item arrow>
                        <span slot="left">量油温时间：</span>
                        <yd-datetime type="datetime" v-model="model.oilTempTime" slot="right"></yd-datetime>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">味道：</span>
                        <select slot="right" v-model="model.smellType">
                            <option value="">请选择</option>
                            <option value="0">一般刺鼻</option>
                            <option value="1">刺鼻</option>
                            <option value="2">不刺鼻</option>
                        </select>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">混水反应：</span>
                        <yd-input slot="right" v-model="model.混水反应" regex="" placeholder="参考值：油水迅速分离，不出现絮状物"></yd-input>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">十六烷值：</span>
                        <yd-input slot="right" v-model="model.十六烷值" regex="" placeholder="请输入十六烷值"></yd-input>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">十六烷指数：</span>
                        <yd-input slot="right" v-model="model.十六烷指数" regex="" placeholder="请输入十六烷指数"></yd-input>
                    </yd-cell-item>

                </yd-cell-group>
                <yd-cell-group title="化验二">

                    <yd-cell-item>
                        <span slot="left">初硫：</span>
                        <yd-input slot="right" v-model="model.初硫" regex="" placeholder="参考值：160-180℃"></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">10%：</span>
                        <yd-input slot="right" v-model="model.percentage10" regex="" placeholder="参考值："></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">50%：</span>
                        <yd-input slot="right" v-model="model.percentage50" regex="" placeholder="参考值：220-280℃"></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">90%：</span>
                        <yd-input slot="right" v-model="model.percentage90" regex="" placeholder="参考值：300-345℃"></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">回流：</span>
                        <yd-input slot="right" v-model="model.回流" regex="" placeholder=""></yd-input>
                        <span slot="right">%</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">干点：</span>
                        <yd-input slot="right" v-model="model.干点" regex="" placeholder="参考值："></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">蚀点：</span>
                        <yd-input slot="right" v-model="model.蚀点" regex="" placeholder="参考值："></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">凝点：</span>
                        <yd-input slot="right" v-model="model.凝点" regex="" placeholder="参考值："></yd-input>
                        <span slot="right">℃</span>
                    </yd-cell-item>

                    <yd-cell-item>
                        <span slot="left">含硫：</span>
                        <yd-input slot="right" v-model="model.含硫" regex="" placeholder="参考值："></yd-input>
                        <span slot="right">PPM</span>
                    </yd-cell-item>
                </yd-cell-group>
                <div>
                    <yd-button size="large" type="primary" @click.native="buttonclick" :disabled="isPrevent">提交</yd-button>
                </div>

            </yd-tab-panel>
            <yd-tab-panel label="记录">
                <yd-search v-model="sv" />
                <yd-cell-group>
                    <yd-infinitescroll :callback="loadList" ref="infinitescroll">
                        <yd-cell-item slot="list" arrow v-for="s in assays" :key="s.id" @click.native="assayclick(s)">
                            <div slot="left">
                                <p>{{s.name}}</p>
                                <p class="col-light-gray">{{s.assayer}}</p>
                            </div>
                            <div slot="right" style="text-align: left;margin-right: 5px">
                                <p v-show="s.assayType == 0" style="color:darkgreen">{{s.store == null?"":s.store.name}}仓</p>
                                <p v-show="s.assayType == 1" style="color:lightcoral">{{s.purchase == null?"":s.purchase.carNo}} / {{s.purchase == null?"":s.purchase.count}}吨</p>
                                <p>{{formatDate(s.createdAt)}}</p>
                            </div>
                        </yd-cell-item>
                        <!-- 数据全部加载完毕显示 -->
                        <span slot="doneTip">没有数据啦~~</span>
                        <!-- 加载中提示，不指定，将显示默认加载中图标 -->
                        <img slot="loadingTip" src="http://static.ydcss.com/uploads/ydui/loading/loading10.svg" />
                    </yd-infinitescroll>
                </yd-cell-group>
            </yd-tab-panel>
        </yd-tab>
        <!--进油单选择-->
        <yd-popup v-model="showPurchases" width="70%" position="right">
            <yd-cell-group title="选择进油单">
                <yd-search v-model="sv" />
                <yd-cell-item v-for="p in purchases" :key="p.id" @click.native="purchaseclick(p)">
                    <div slot="left">
                        <p>{{p.carNo}}</p>
                        <p class="col-light-gray">{{p.name}}</p>
                    </div>
                    <div slot="right" class="col-light-gray">{{p.count}}吨 / {{p.product.name}}</div>
                </yd-cell-item>
            </yd-cell-group>
        </yd-popup>
        <!--化验单详细-->
        <yd-popup v-model="showDetail" position="right" width="70%">
            <yd-cell-group :title="assay.name">
                <yd-cell-item>
                    <span slot="left">视密：</span>
                    <span slot="right">{{assay.视密}}</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">标密：</span>
                    <span slot="right">{{assay.标密}}</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">闭口闪点：</span>
                    <span slot="right">{{assay.闭口闪点}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">油温：</span>
                    <span slot="right">{{assay.temperature}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">量油温时间：</span>
                    <span slot="right">{{assay.oilTempTime}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">味道：</span>
                    <span v-show="assay.smellType == 0" slot="right">一般刺鼻</span>
                    <span v-show="assay.smellType == 1" slot="right">刺鼻</span>
                    <span v-show="assay.smellType == 2" slot="right">不刺鼻</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">混水反应：</span>
                    <span slot="right">{{assay.混水反应}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">十六烷值：</span>
                    <span slot="right">{{assay.十六烷值}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">十六烷指数：</span>
                    <span slot="right">{{assay.十六烷指数}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">初硫：</span>
                    <span slot="right">{{assay.初硫}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">10%：</span>
                    <span slot="right">{{assay.percentage10}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">50%：</span>
                    <span slot="right">{{assay.percentage50}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">90%：</span>
                    <span slot="right">{{assay.percentage90}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">回流：</span>
                    <span slot="right">{{assay.回流}}%</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">干点：</span>
                    <span slot="right">{{assay.干点}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">蚀点：</span>
                    <span slot="right">{{assay.蚀点}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">凝点：</span>
                    <span slot="right">{{assay.凝点}}℃</span>
                </yd-cell-item>

                <yd-cell-item>
                    <span slot="left">含硫：</span>
                    <span slot="right">{{assay.含硫}}℃</span>
                </yd-cell-item>
                <div class="align-center">
                    <yd-button type="primary" style="width: 90%" @click.native="getPrintAssay(assay.id, '收银台')">打印到【收银台】</yd-button>
                    <yd-button type="primary" class="mtop10" style="width: 90%" @click.native="getPrintAssay(assay.id, '地磅室')">打印到【地磅室】</yd-button>
                </div>
            </yd-cell-group>
        </yd-popup>
    </div>
</template>

<script src="./assay.ts" />

