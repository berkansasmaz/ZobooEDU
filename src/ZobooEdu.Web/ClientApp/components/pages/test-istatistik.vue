<template>
  <div>
    <page-head icon="chart-line" title="Test İstatistik" />
 
   <div class="bg-dark">
			<h2 class="text-center bg-warning text-dark">Genel Başarı</h2>
		<div class="row justify-content-center"  v-for="(stat, index) in stats" :key="index">
		<div class="col-lg-4 col-md-4 col-sm-6 col-xs-12"  v-if="index == stats.length-1">
		<div class="card border-primary mt-3 mr-2 mb-4" >
		<p class="text-center bg-primary text-white">Tüm testlerin doğru ve yanlış sayısı</p>
		<div class="text-center">Başarım Oranı: {{genelBasarimOrani}}%</div>
		<apexchart type="pie" :options="stat.chart" :series="stat.chart.series2" class="mt-4 ml-2 mr-2"></apexchart>
		</div>
		</div>
		</div>
		
		<h2 class="text-center bg-warning text-dark">Testlerin Başarısı</h2>
		<div class="row">
		<div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" v-for="(stat, index) in stats" :key="index">
		<div class="card border-primary ml-2 mr-2 mb-2">
		<p class="text-center bg-primary text-white">Test {{index+1}}</p>
		<div class="text-center">Başarım Oranı: {{stat.basariOrani}}%</div>
		<apexchart type="pie" :options="stat.chart" :series="stat.chart.series" class="mt-4 ml-2 mr-2"></apexchart>
		</div>
		</div>
		</div>
   </div>
  </div>
</template>

<script>
  import service from "service/soru-cevap";
  export default {
    data() {
      return {
		 	stats: [],
			dogruSayisi: 0,
			yanlisSayisi: 0,
			toplamDogruSayisi: 0,
			toplamYanlisSayisi: 0,
			genelBasarimOrani: {"type" : Int8Array}
		
      }
    },
    async mounted() {
	  var result = await service.list();
	  if (result.data && result.data.length)
		result.data.map((item,index) => {
		this.dogruSayisi = result.data[index].dogruSayisi;
		this.yanlisSayisi = result.data[index].yanlisSayisi;
		this.toplamDogruSayisi += this.dogruSayisi;
		this.toplamYanlisSayisi += this.yanlisSayisi;
		this.genelBasarimOrani = 100 * (this.toplamDogruSayisi) / (this.toplamDogruSayisi +this.toplamYanlisSayisi);

			item.chart = {
				chart: {
                width: 380,
                type: 'pie',
			},
			colors:['#00A100', '#FF0000'],
            labels: ['Doğru', 'Yanlış'],
			series: [this.dogruSayisi, this.yanlisSayisi],
			series2: [this.toplamDogruSayisi, this.toplamYanlisSayisi],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
		}
				this.stats.push(item);
		});
}
};

</script>
