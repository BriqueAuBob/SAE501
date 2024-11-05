<script setup lang="ts">
import { PropType } from "vue";

type Member = {
  name: string;
  role: string;
  image: string;
};

defineProps({
  member: {
    type: Object as PropType<Member>,
    required: true,
  },
});
</script>

<template>
  <div class="bg-white rounded-lg shadow-sm overflow-hidden">
    <img
      :src="member.image"
      alt="Team member"
      class="w-full h-64 object-cover"
    />
    <div class="p-4">
      <h3 class="text-lg font-bold">{{ member.name }}</h3>
      <p class="text-sm text-gray-500">{{ member.role }}</p>
    </div>
  </div>
</template>
