<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
     <router-view>
      
     </router-view>
    </div>
  </div>
</template>

<script>
import Alunos from "./modules/alunos/views/index";
import Professores from "./modules/professores/views/index";
import Nav from "./modules/_nav/Nav";
import Sobre from "./modules/shared/views/sobre";
import './assets/style.css';

/* eslint-disable */
export default {
  name: "app",
  components: {
    Professores,
    Sobre,
    Alunos,
    Nav,
  },
};
</script>