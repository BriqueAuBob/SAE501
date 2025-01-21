<script setup lang="ts">
import type { News } from "@/types/news";
import { PropType } from "vue";
import VueMarkdown from "vue-markdown-render";

defineProps({
  news: {
    type: Object as PropType<News>,
    required: true,
  },
});
</script>

<template>
  <article>
    <h1 class="font-bold text-lg">{{ news.title }}</h1>
    <h2 class="font-medium text-md text-gray-500">{{ news.description }}</h2>
    <vue-markdown class="text-sm my-4" :source="news.content" />
    <div class="text-gray-500 mt-2 text-xs">
      Publié le {{ new Date(news.date).toLocaleDateString() }} à
      {{ new Date(news.date).toLocaleTimeString() }}
    </div>
    <hr class="border-gray-200 my-2" />
  </article>
</template>
