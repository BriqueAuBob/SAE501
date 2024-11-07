<script setup lang="ts">
import TeamMember from "@/components/global/TeamMember.vue";
import Brandon from "@/assets/images/team/brandon.jpeg";

const team = [
  {
    name: "Brandon Clément",
    role: "Développeur et Game Designer",
    image: Brandon,
  },
];
</script>

<template>
  <section class="container py-8">
    <h2 class="text-2xl font-bold mb-2">Team</h2>
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
      <TeamMember v-for="member in team" :key="member.name" :member="member" />
    </div>
  </section>
</template>
