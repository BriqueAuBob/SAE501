<script setup lang="ts">
import Header from "@/components/homepage/Header.vue";
import Infos from "@/components/homepage/Infos.vue";
import News from "@/components/homepage/News.vue";
import Team from "@/components/homepage/Team.vue";
</script>

<template>
  <Header />
  <Team />
  <div class="grid grid-cols-2 gap-4 container py-8">
    <Infos />
    <News />
  </div>
</template>
