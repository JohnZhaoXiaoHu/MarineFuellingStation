﻿import Vue from 'vue';
import VueRouter from 'vue-router';
import store from './store'

Vue.use(VueRouter);

const routes = [
    { path: '/sales/plan', component: require('./components/sales/plan.vue') },
    { path: '/sales/order', component: require('./components/sales/order.vue') },
    { path: '/sales/myorder', component: require('./components/sales/myorder.vue') },
    { path: '/sales/myclient', component: require('./components/sales/myclient.vue') },
    { path: '/sales/boatclean', component: require('./components/sales/boatclean.vue') },

    { path: '/produce/buyboard', component: require('./components/produce/buyboard.vue') },
    { path: '/produce/planboard', component: require('./components/produce/planboard.vue') },
    { path: '/produce/assay', component: require('./components/produce/assay.vue') },
    { path: '/produce/unload', component: require('./components/produce/unload.vue') },
    { path: '/produce/load', component: require('./components/produce/load.vue') },
    { path: '/produce/landload', component: require('./components/produce/landload.vue') },
    { path: '/produce/movestore', component: require('./components/produce/movestore.vue') },
    { path: '/produce/movestoreact', component: require('./components/produce/movestoreact.vue') },

    { path: '/oilstore/inout', component: require('./components/oilstore/inout.vue') },
    { path: '/oilstore/store', component: require('./components/oilstore/store.vue') },
    { path: '/oilstore/product', component: require('./components/oilstore/product.vue') },
    { path: '/oilstore', component: require('./components/oilstore/oilstore.vue') },

    { path: '/purchase/purchase', component: require('./components/purchase/purchase.vue') },
    
    { path: '/client/client', component: require('./components/client/client.vue') },

    { path: '/user/user', component: require('./components/user/user.vue') },

    { path: '/finance/cashier', component: require('./components/finance/cashier.vue') },

    { path: '/funcmenu', component: require('./components/funcmenu/funcmenu.vue') },
    { path: '/', component: require('./components/home/home.vue') },
    { path: '/counter', component: require('./components/counter/counter.vue') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue') },
    { path: '/ydui', component: require('./components/ydui/ydui.vue') },
    {
        //服务端一律跳转到这个URL上
        path: '/wxhub/:id/:redirectUrl', redirect: to => {
            /**
            * 通过dispatch触发保存openid的action
            * 将URL上的OPENID保存到store中
            */
            store.commit('setUserName', decodeURI(to.params.id));
            //在回跳到需要来访的正确页面
            return decodeURI(to.params.redirectUrl);
        }
    }
];

var router = new VueRouter({ mode: 'hash', routes: routes });
//在每次使用路由时对username进行校验，如果不存在则获取username到前端
router.beforeEach((to, from, next) => {
    console.log(store.state)
    if (store.state.username != "") {
        next();
    } else {
        console.log(to);
        window.location.href = "/home/GetOpenId?id=" + encodeURIComponent(to.fullPath);
    }
});
export default router;