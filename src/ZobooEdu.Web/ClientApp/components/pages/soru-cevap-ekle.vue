<template>
  <div>
    <page-head icon="plus" title="Soru Ekle" /> 
   <mvi-text title="Konu" placeholder = "Sorunun konusunu yazınız" v-model="model.konu" />
    <mvi-text title="Resim" placeholder = "Type your website url for test" v-model="model.resimYolu"/>
	 <mvi-text title="Soru" placeholder = "Soruyu yazınız" v-model="model.soruMetni" />
    <mvi-text title="Cevap-1" placeholder = "Soruya cevap yazınız" v-model="model.cevap1" />
    <mvi-text title="Cevap-2" placeholder = "Soruya cevap yazınız" v-model="model.cevap2" />
    <mvi-text title="Cevap-3" placeholder = "Soruya cevap yazınız" v-model="model.cevap3" />
    <mvi-text title="Cevap-4" placeholder = "Soruya cevap yazınız" v-model="model.cevap4" />
    <mvi-text title="Doğru Cevap" placeholder = "Sorunun doğru cevabını yazınız" v-model="model.dogruCevap" />

    <button @click="save" class="btn btn-success">
		<icon icon="plus"/>	Save
    </button>
  </div>
</template>

<script>
  import service from "service/soru-cevap";
  import router from "@/router";

  export default {
    data() {
      return {
         model: {
		  konu: "",
		  resimYolu : "",
		  soruMetni : "",
		  cevap1 : "",
		  cevap2  : "",
		  cevap3  : "",
		  cevap4  : "",
		  dogruCevap : ""
		}
    }
},
    methods: {
		async save() {
			var result = await service.save(this.model);
			
			this.$router.go(0);
		}
	}
  };

</script>
