<script setup lang="ts">
const APP_NAME = import.meta.env.VITE_APP_NAME;
</script>

<template>
  <footer class="container text-center mb-4 text-gray-700">
    &copy; {{ APP_NAME }} {{ new Date().getFullYear() }} - Tous droits réservés
  </footer>
</template>
