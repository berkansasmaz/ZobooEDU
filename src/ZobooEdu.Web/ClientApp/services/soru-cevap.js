import {
	http
  } from "utils/http";

  const MonitoringService = {
	async deleteIstatistik() {
		var result = await http.delete("/api/v1/istatistik");
		if (result.status === 200) {
		  return result.data;
		} else {
		  console.error(result.error);
		  throw result.error;
		 }
	},
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
		var result = await http.get("/api/v1/sorucevap/" + id);
		if (result.status === 200) {
		  return result.data;
		} else {
		  console.error(result.error);
		  throw result.error;
		}
	  },

	async save(value) {
	  var result = await http.post("/api/v1/sorucevap", value);
	  if (result.status === 200) {
		return result.data;
	  } else {
		console.error(result.error);
		throw result.error;
	  }
	},

	async update(value) {
		var result = await http.put("/api/v1/sorucevap", value);
		if (result.status === 200) {
		  return result.data;
		} else {
		  console.error(result.error);
		  throw result.error;
		}
	  },

	  async delete() {
		var result = await http.delete("/api/v1/sorucevap");
		if (result.status === 200) {
		  return result.data;
		} else {
		  console.error(result.error);
		  throw result.error;
		}
	  },
  };

  export default MonitoringService;
