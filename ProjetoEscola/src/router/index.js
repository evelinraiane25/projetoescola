import Vue from "vue";
import Router from "vue-router";
import Alunos from "../modules/alunos/views/index";
import AlunoDetalhe from "../modules/alunos/views/detalhe";
import Professores from "../modules/professores/views/index";
import Sobre from "../modules/shared/views/sobre";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      redirect: "/alunos",
    },
    {
      path: "/professores",
      nome: "Professores",
      component: Professores,
    },
    {
      path: "/alunos",
      nome: "Alunos",
      component: Alunos,
    },
    {
      path: "/alunos/:professorid",
      nome: "Alunos",
      component: Alunos,
    },
    {
      path: "/alunos/detalhe/:id",
      nome: "AlunoDetalhe",
      component: AlunoDetalhe,
    },
    {
      path: "/sobre",
      nome: "Sobre",
      component: Sobre,
    },
  ],
});
