import axios from "axios";

const config = axios.create({
  baseURL: "/api",
});

export default config;
