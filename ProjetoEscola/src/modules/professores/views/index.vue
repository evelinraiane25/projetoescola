<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>#</th>
        <th>Nome</th>
        <th>Alunos</th>
        <!-- Comentario -->
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td class="center">{{ professor.id }}</td>

          <router-link
            v-bind:to="`/alunos/${professor.id}`"
            tag="td"
            style="cursor: pointer"
          >
            {{ professor.nome }} {{ professor.sobrenome }}
          </router-link>

          <td class="center">{{ professor.quantidadeAlunos }}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum professor encontrado</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../../shared/views/titulo";
import { mapActions } from "vuex";

export default {
  name: "Professores",
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Professores",
      professores: [],
      alunos: [],
    };
  },
  methods: {
    /* eslint-disable */
    ...mapActions({
      listarAlunos: "alunos/listarAlunos",
      listarProfessores: "professores/listarProfessores",
    }),

    //Created
    carregar() {
      this.listarAlunos().then((res) => {
        this.alunos = res.data;
        this.carregarProfessores();
      });
    },

    carregarProfessores() {
      this.listarProfessores().then((res) => {
        this.professores = res.data;
        this.alunosPorProfessor();
      });
    },

    alunosPorProfessor() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          quantidadeAlunos: this.alunos.filter(
            (aluno) => aluno.professor && aluno.professor.id == professor.id
          ).length,
        };

        this.professores[index] = professor;
      });
    },
  },

  mounted() {
    this.carregar();
  },
};
</script>
