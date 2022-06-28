<template>
  <div id="app">
      <Alunos />
  </div>
</template>

<script>
import Alunos from "./modules/alunos/views/index.vue";

export default {
  name: "app",
  components:{
    Alunos,
  },
};
</script>


<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

body,
html {
  margin: 0;
  height: 100%;
}

#app {
}

.btn {
  border: 1px solid #000;
  cursor: pointer;
  padding: 1px solid #000;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
}

/* .btn:hover {
  text-shadow: 1px, 1px, 1px black;
  border-bottom: 1px solid black;
  margin-top: 3px;
} */

.btnDanger{
  background: #ee5050f0;
}

.btnInput {
  border: 0px;
  padding: 20px;
  font-size: 0.9em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

/* .btnInput:hover {
  padding: 20px;
  width: 0px;
  border: 0px;
} */

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background: #e0edf4;
  margin: 2px;
  color: #3e5252;
}

table thead th {
  background: rgb(184, 208, 216) !important;
  font-size: 1, 2em;
  padding: 10px 0px;
  text-align: center !important;
}

input{
  border: 0;
  padding: 20px;
  font-size: 1,3em;
  color: #819191;
  display: inline;
}

.colPequeno {
  width: 5%;
}
</style>