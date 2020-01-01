<template>
  <div>
    <page-head icon="chart-line" title="Sınav Sonuç" />
   <h2 class="text-center bg-primary text-dark">Testin Başarısı</h2>


    <div class="row justify-content-center" v-for="(stat, index) in stats" :key="index">
      <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 " v-if="index == stats.length-1">
        <div class="card border-primary mr-2 mb-2" >
			<p class="text-center bg-primary text-white">Test {{index+1}}</p>
			<div class="text-center">Başarım Oranı: {{stat.basariOrani}}%</div>
          <!-- <apexchart type="bar" height="350" :options="stat.chart" :series="stat.chart.series" class="mt-4 ml-2 mr-2"></apexchart> -->
		          <apexchart type="bar" height="350"  :options="stat.chart.chartOptions" :series="stat.chart.series"></apexchart>

        </div>
      </div>
    </div>

	
  </div>
</template>

<script>
 import service from "service/test";
 export default {
 	data() {
 		return {
			 stats: [],
			 konu: "",
			 dogruSayisi: 0
 		}
 	},
 	async mounted() {
 		var result = await service.getSonuc(this.$route.params.id);
 		if (result.data && result.data.length)
 			result.data.map((item, index) => {
				 this.konu = result.data[index].konu;
				 if (result.data[index].isDogruMu) {
					  this.dogruSayisi += 1; 
				 }	
 				item.chart = {
							series: [{
								data: [this.dogruSayisi]
							}],
							chartOptions: {
								chart: {
								type: 'bar',
								height: 350
								},
								plotOptions: {
								bar: {
									horizontal: true,
								}
								},
								dataLabels: {
								enabled: false
								},
								xaxis: {
								categories: [this.konu
								],
								}
							},							
			}
				 this.stats.push(item);
 			});
 	}
 };
</script>