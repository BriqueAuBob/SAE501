<script setup lang="ts">
import News from "../global/News.vue";
</script>

<template>
  <div class="flex flex-col gap-2">
    <News v-for=" in 5" />
  </div>
</template>
