<script setup lang="ts">
import Progress from "@/components/ui/Progress.vue";

const APP_NAME = import.meta.env.VITE_APP_NAME;
</script>

<template>
  <header class="container py-8">
    <h1 class="text-4xl font-bold mb-4">{{ APP_NAME }}</h1>
    <div class="grid lg:grid-cols-2 gap-4 items-center">
      <img src="/thumbnail.png" alt="DrivingRoad" class="w-full rounded-xl" />
      <div class="w-full">
        <Progress :value="70" :max="100" label="Avancée du projet" />
        <p class="text-md mt-2 leading-snug text-left">
          Ex adipisicing aliquip minim minim ex magna reprehenderit officia
          dolor. Exercitation est velit non qui. Occaecat aliquip fugiat anim
          est laboris. Sunt sunt sit aliqua ullamco. Eu voluptate veniam non
          nulla aliqua dolore ut irure proident occaecat adipisicing aliquip
          aliqua adipisicing. Esse laborum esse minim veniam eu quis incididunt
          officia proident sint sint. Proident qui in dolore non culpa qui.
        </p>
      </div>
    </div>
  </header>
</template>
