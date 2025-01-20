<script setup lang="ts">
import TeamMember from "@/components/global/TeamMember.vue";
import useTeam from "@/composables/useTeam";

const { data: team } = useTeam();
</script>

<template>
  <section class="container py-8">
    <h2 class="text-2xl font-bold mb-2">Team</h2>
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
      <TeamMember v-for="member in team" :key="member.name" :member="member" />
    </div>
  </section>
</template>
