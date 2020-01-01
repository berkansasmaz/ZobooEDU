<template>
  <div>
    <div v-if="soru.testSayisi == 1">
		<page-head icon="pen" title="Test Ol" />
		<div class="text-center" v-if="baslaButtonGoster">
		<button class="btn btn-primary" @click="basla">Teste Başla</button>
		</div>
	</div>
	    <div v-if="soru.testSayisi >= 2">
			<page-head icon="exclamation-circle" title="Test Ol" />
			<h3 class="text-center"><icon	icon="exclamation-circle" />	Aynı gün içerisinde 2 test olamazsınız!!!</h3>
	</div>

    <div v-if="soruGöster">
      <template v-if="!isTestBittiMi">
        <circular-count-down-timer :initial-value="3000" :stroke-width="5" :seconds-stroke-color="'#f00'"
          :minutes-stroke-color="'#0ff'" :hours-stroke-color="'#0f0'" :underneath-stroke-color="'lightgrey'"
          :seconds-fill-color="'#00ffff66'" :minutes-fill-color="'#00ff0066'" :hours-fill-color="'#ff000066'"
          :size="100" :padding="4" :hour-label="'hours'" :minute-label="'minutes'" :second-label="'seconds'"
          :show-second="true" :show-minute="true" :show-hour="false" :notify-every="'minute'" @finish="finished">
        </circular-count-down-timer>
      </template>
<template v-if="!isTestBittiMi">
		<h3 class="text-light">Konu: {{soru.konu}}</h3>
		<br>
		<h4 class="text-dark">Soru: &nbsp;{{soru.soruMetni}}</h4>
		<div class="bg-light" v-if="!isSecildiMi">
		<div @click="cevap1">
		<button class="btn btn-link" @click="sec">
		<p>A-)&nbsp;{{soru.cevap1}}</p>
		</button>
		</div>
		<div @click="cevap2">
		<button class="btn btn-link" @click="sec">
		<p>B-)&nbsp;{{soru.cevap2}}</p>
		</button>
		</div>
		<div @click="cevap3">
		<button class="btn btn-link" @click="sec">
		<p>C-)&nbsp;{{soru.cevap3}}</p>
		</button>
		</div>
		<div @click="cevap4">
		<button class="btn btn-link" @click="sec">
		<p>D-)&nbsp;{{soru.cevap4}}</p>
		</button>
		</div>
		</div>
</template>
		<div v-for="(_, index) in 1" :key="index">
					<template :v-if="index < limit">
					<div v-if="!isTestBittiMi"  class="text-center mt-4 mb-4">
					<button  v-if="isSecildiMi" class="btn btn btn-success" @click="update">İleri</button>
					</div>
					</template>
		</div>
			<div v-if="isTestBittiMi" class="text-center mt-4 mb-4">
					<button class="btn btn btn-success" @click="sonuc">Testi Bittir</button>
			</div>
    </div>
  </div>
</template>

<script>
  import service from "service/soru-cevap";
  import testService from "service/test";
  import router from "@/router";
  import Vue from 'vue';

  export default {
    data() {
      return {
		soru: {},
		randomValue: 0,
		soruGöster: false,
		isTestBittiMi: false,
        baslaButtonGoster: true,
        isSecildiMi: false,
		id: this.$route.params.id,
		limit: 50, // TODO limit değişince başarım değişir unutma ve değiştir todo lara bak var orda.
		testModel: {
			dogruSayisi: 0,
			yanlisSayisi: 0
		},
		bosSayisi: 0,
      }
    },
    async mounted() {
      var result = await service.get(this.$route.params.id);
      if (result.success) {
        this.soru = result.data;
      }
    },
    watch: {
      'this.$route.params.id': 'id'
    },
    methods: {
      cevap1() {
        if (this.soru.dogruCevap == this.soru.cevap1) {
		  this.soru.isDogruMu = true;
		  this.testModel.dogruSayisi += 1;
        } else{
		  this.soru.isDogruMu = false;
		  this.testModel.yanlisSayisi += 1;
		}
      },
      cevap2() {
        if (this.soru.dogruCevap == this.soru.cevap2) {
		  this.soru.isDogruMu = true;
			this.testModel.dogruSayisi += 1;
        } else{
		  this.soru.isDogruMu = false;
		  this.testModel.yanlisSayisi += 1;
		}
      },
      cevap3() {
        if (this.soru.dogruCevap == this.soru.cevap3) {
		  this.soru.isDogruMu = true;
		  this.testModel.dogruSayisi += 1;
        } else{
		  this.soru.isDogruMu = false;
		  this.testModel.yanlisSayisi += 1;
		}
      },
      cevap4() {
        if (this.soru.dogruCevap == this.soru.cevap4) {
		  this.soru.isDogruMu = true;
		  this.testModel.dogruSayisi += 1;
		} else{
		  this.soru.isDogruMu = false;
		  this.testModel.yanlisSayisi += 1;
		}
      },
      async basla() {
		  var random =  Math.random() *10000  + 1;
		this.randomValue =  Math.round(random);
		var result = await service.delete();
        this.id = this.soru.soruId;
        this.soruGöster = true;
        this.baslaButtonGoster = false;
      },
      sec() {
        this.isSecildiMi = true;
      },
      async update() {
		this.limit -= 1;
        var result = await service.update(this.soru);
        var result = await service.get(this.$route.params.id);
        if (result.success) {
          this.soru = result.data;
		  this.isSecildiMi = false;
		  if (this.limit == 0) {
			  this.isTestBittiMi = true;
			  this.bosSayisi = this.limit - (this.testModel.dogruSayisi + this.testModel.yanlisSayisi);
			 
			   Vue.notify({
				title: 'Testiniz bitti.',
				text: 'Sonuçları görmeye hazırmısın.',
				type: 'warn'
        })
		  }
        }
	  },
	  async sonuc(){
		var result = await testService.save(this.testModel);
        router.push({
          name: "sinav-sonuc" , params: { id: this.id }
        })

	  },
     async  finished() {
		var result = await service.delete();
        router.push({
          name: "home"
        })
        Vue.notify({
          title: 'Error',
          text: 'Süreniz bitti',
          type: 'error'
        })
      }
    },
  };

</script>
