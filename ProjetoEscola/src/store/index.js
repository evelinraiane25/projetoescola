import Vue from "vue";
import Vuex from "vuex";

import alunos from "@/modules/alunos/store";
import professores from "@/modules/professores/store";

Vue.use(Vuex);

export const store = new Vuex.Store({
  modules: {
    alunos: alunos,
    professores: professores,
  },
  state: {
    width: 0,
    isLoading: false,
  },
  getters: {
    isLoading: (state) => state.isLoading,
    userLoggedEmail: (state) => state.account.current.userEmail,
  },
  mutations: {
    showLoading() {
      this.state.isLoading = true;
    },
    hideLoading() {
      this.state.isLoading = false;
    },
  },
});
