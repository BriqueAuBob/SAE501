<script setup lang="ts">
import Progress from "@/components/Progress.vue";
</script>

<template>
  <header class="container text-center py-8">
    <h1 class="text-4xl font-bold mb-4">Driving Road</h1>
    <img
      src="https://placehold.co/1920x1080"
      alt="DrivingRoad"
      class="lg:w-1/2 mx-auto"
    />
    <div class="lg:w-1/2 mt-4 mx-auto">
      <Progress :value="1" :max="100" label="Avancée du projet" />
    </div>
  </header>
</template>
