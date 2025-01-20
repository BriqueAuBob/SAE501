<script setup lang="ts">
import News from "../global/News.vue";
import useNews from "@/composables/useNews";

const { data: news } = useNews();
</script>

<template>
  <div class="flex flex-col gap-2">
    <News v-for="n in news" :news="n" />
  </div>
</template>
