<template>
  <div>
    <page-head icon="chart-line" title="Sınav Sonuç" />
   <h2 class="text-center bg-dark text-white">Testin Başarısı</h2>



       <div class="card">
              <div class="card-datatable table-responsive">
                <table class="table table-hover table-bordered">
                  <thead class="thead-dark">
                    <tr>
					<th>#</th>
					 <th>Konu</th>
                      <th>Cevap</th>
                    </tr>
                  </thead>
				  <tbody v-for="(item, index) in sorular" :key="index">
						  	<tr>
								<td >{{index + 1}}. Soru</td>
								<td >{{item.konu}}</td>
								<td v-if="item.isDogruMu == true">Doğru</td>	
								<td v-if="item.isDogruMu == false">Yanlış</td>							
							  </tr>
					
				  </tbody>
                </table>
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
			 toplamKonuSayisi: 0,
			 sayac: 0,
			  sorular: [],
 		}
 	},
 	async mounted() {
		 var result = await service.getSonuc(this.$route.params.id);
		 this.stats = result.data;
		 this.toplamKonuSayisi = this.stats.length -1;
		 this.testeGoreVeriAl();
	 },
	 methods: {
		 testeGoreVeriAl(){
			 while (true) {
					if (this.sayac == 50) { //Todo Soru sayısını 50  yap 
						break
					}
					this.sorular.push(this.stats[this.toplamKonuSayisi--])		 
					 this.sayac +=1;
			 }
			

		 }
	 },
 };
</script>