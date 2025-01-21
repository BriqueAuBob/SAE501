import useFetch from "./useFetch";
import type { News } from "@/types/news";
import { computed } from "vue";

export default function useNews() {
  const { data } = useFetch<News[]>("/news");

  const sortedNews = computed(() => {
    return data.value?.sort((a, b) => {
      return new Date(b.date).getTime() - new Date(a.date).getTime();
    });
  });

  return { data, sortedNews };
}
