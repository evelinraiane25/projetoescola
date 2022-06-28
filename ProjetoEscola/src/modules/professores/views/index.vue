<template>
  <div></div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "Professores",
  components: {
  },
  data() {
    return {
      professores:[]
    };
  },
  methods: {
    /* eslint-disable */
    ...mapActions({
      list: "professores/list",
    }),

    listar() {
      this.professores = [];
      this.list().then((resp) => (this.professores = resp.data));
    },
  },
  mounted() {
    this.listar();
  },
};
</script>
