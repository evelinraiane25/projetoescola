<template>
    <div>
      <div style="display:flex; width: 50%">
        <h2>{{ texto }}</h2>
        <div class="voltar">
          <slot></slot>
         <button v-show="btnVoltar" class="btn btnVoltar" @click="voltar()">voltar</button>
        </div>
      </div>
    </div>
</template>

<script>
export default {
  props: {
    texto: String,
    btnVoltar: Boolean
  },

  methods: {
    voltar(){
      this.$router.back();
    }
  },
};
</script>
