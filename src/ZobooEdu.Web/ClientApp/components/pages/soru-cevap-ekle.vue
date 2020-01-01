<template>
  <div>
    <page-head icon="plus" title="Soru Ekle" />
    <div class="card mb-4 mt-4">
		 <h6 class="card-header">
   			     <div>Konu</div>
      	</h6>
      <div class="card-body ">
        <div class="form-group">
          <select v-model="model.konu" class="form-control">
            <option value="Polinom">Polinom</option>
            <option value="Üslü Sayılar">Üslü Sayılar</option>
            <option value="Karekök">Karekök</option>
			<option value="Limit">Limit</option>
            <option value="Rasyonel Sayılar">Rasyonel Sayılar</option>
            <option value="Logaritma">Logaritma</option>
            <option value="Olasılık">Olasılık</option>
            <option value="Trigonometri">Trigonometri</option>
            <option value="Türev">Türev</option>
            <option value="İntegral">İntegral</option>
            <option value="Oran Orantı">Oran Orantı</option>
            <option value="Mutlak Değer">Mutlak Değer</option>
            <option value="Mantık">Mantık</option>
            <option value="Kümeler">Kümeler</option>
          </select>
        </div>
      </div>
    </div>
    <mvi-text title="Soru" placeholder="Soruyu yazınız" v-model="model.soruMetni" />
    <mvi-text title="Cevap-1" placeholder="Soruya cevap yazınız" v-model="model.cevap1" />
    <mvi-text title="Cevap-2" placeholder="Soruya cevap yazınız" v-model="model.cevap2" />
    <mvi-text title="Cevap-3" placeholder="Soruya cevap yazınız" v-model="model.cevap3" />
    <mvi-text title="Cevap-4" placeholder="Soruya cevap yazınız" v-model="model.cevap4" />

	<div class="card mb-4 mt-4">
			<h6 class="card-header">
					<div>Doğru Cevap</div>
			</h6>
		<div class="card-body ">
			<div class="form-group">
			<select v-model="model.dogruCevap" class="form-control">
				<option v-if="model.cevap1" :value=model.cevap1>{{model.cevap1}}</option>
				<option  v-if="model.cevap2" :value=model.cevap2>{{model.cevap2}}</option>
				<option v-if="model.cevap3" :value=model.cevap3>{{model.cevap3}}</option>
				<option v-if="model.cevap4" :value=model.cevap4>{{model.cevap4}}</option>
			</select>
			</div>
		</div>
		</div>

    <div class="text-center">
		<button @click="save" class="btn btn-success">
		<icon icon="plus" /> Save
		</button>
	</div>
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
          resimYolu: "",
          soruMetni: "",
          cevap1: "",
          cevap2: "",
          cevap3: "",
          cevap4: "",
          dogruCevap: ""
        }
      }
    },
    methods: {
      async save() {
        var result = await service.save(this.model);

        this.$router.go(0);
      }
    },
    async mounted() {
      var result = await service.deleteIstatistik();
    }
  };

</script>
