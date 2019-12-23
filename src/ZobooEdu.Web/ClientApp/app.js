import Vue from 'vue';
import axios from 'axios';
import router from './router/index';
import store from './store';
import { sync } from 'vuex-router-sync';
import App from 'components/root/app-root';
import { FontAwesomeIcon } from './icons';
import PageHead from 'components/shared/page-head';
import Notifications from 'vue-notification';
import VueContentPlaceholders from 'vue-content-placeholders';
import ZBIText from 'components/Input/text';
import CircularCountDownTimer from "vue-circular-count-down-timer";


Vue.use(VueContentPlaceholders);
Vue.use(CircularCountDownTimer);

import VueApexCharts from 'vue-apexcharts';
Vue.use(VueApexCharts);

Vue.component('apexchart', VueApexCharts);

// Input Controls

Vue.use(Notifications);


// Registration of global components
Vue.component('icon', FontAwesomeIcon);
Vue.component('page-head', PageHead);
//Registration for Inputs Controls 
Vue.component('mvi-text', ZBIText);

Vue.prototype.$http = axios;

sync(store, router);

const app = new Vue({
	store,
	router,
	...App
});

export {
	app,
	router,
	store
};
