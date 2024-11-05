<script setup lang="ts">
import { computed, defineProps } from "vue";

const props = defineProps<{
  value: number;
  max: number;
  label: string;
}>();

const percentage = computed(() => (props.value / props.max) * 100);
</script>

<template>
  <div class="relative">
    <div class="w-full h-4 bg-gray-200 rounded-full"></div>
    <div
      class="absolute top-0 left-0 h-full bg-blue-500 rounded-full"
      :style="{ width: `${percentage}%` }"
    ></div>
  </div>
  <div class="flex justify-between mt-0.5">
    <span class="text-gray-500 text-sm">{{ label }}</span>
    <div class="text-gray-500 text-right text-sm mt-1">{{ percentage }}%</div>
  </div>
</template>
