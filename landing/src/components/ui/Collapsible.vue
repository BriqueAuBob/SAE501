<script setup lang="ts">
import { onMounted } from "vue";

const model = defineModel();

const props = defineProps({
  title: String,
  description: String,
  defaultValue: {
    type: Boolean,
    default: false,
  },
});

onMounted(() => {
  model.value = props.defaultValue;
});

const toggle = () => {
  model.value = !model.value;
};
</script>

<template>
  <div class="border border-gray-200 rounded-lg overflow-hidden">
    <button
      class="flex justify-between items-center p-4 cursor-pointer w-full bg-gray-200"
      @click="toggle"
    >
      <h3 class="text-lg font-bold">{{ title }}</h3>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        class="h-6 w-6 ease-in duration-100"
        :class="{ 'transform rotate-180': model }"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M19 9l-7 7-7-7"
        />
      </svg>
    </button>
    <Transition name="scale">
      <div v-if="model" class="p-4">
        <slot />
      </div>
    </Transition>
  </div>
</template>
