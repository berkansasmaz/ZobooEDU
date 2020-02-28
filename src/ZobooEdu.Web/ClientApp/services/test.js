import {
	http
  } from "utils/http";

  const MonitoringService = {
	async list() {
	  var result = await http.get("/api/v1/istatistik");
	  if (result.status === 200) {
		return result.data;
	  } else {
		console.error(result.error);
		throw result.error;
	  }
	},
	async get(id) {
		var result = await http.get("/api/v1/istatistik/" + id);
		if (result.status === 200) {
		  return result.data;
		} else {
		  console.error(result.error);
		  throw result.error;
		}
	  },

	async save(value) {
	  var result = await http.post("/api/v1/istatistik/", value);
	  if (result.status === 200) {
		return result.data;
	  } else {
		console.error(result.error);
		throw result.error;
	  }
	},

	async update(value) {
		var result = await http.put("/api/v1/istatistik/", value);
		if (result.status === 200) {
		  return result.data;
		} else {
		  console.error(result.error);
		  throw result.error;
		}
	  },
	  async getSonuc(id){
		var result = await http.get("/api/v1/istatistik/" + id);
		if (result.status === 200) {
			return result.data;
		  } else {
			console.error(result.error);
			throw result.error;
		  }
	  }
  };

  export default MonitoringService;
