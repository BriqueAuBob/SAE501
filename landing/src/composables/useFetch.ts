import fetch from "@/utils/fetch";
import { onMounted, ref } from "vue";

export default function useFetch<T>(url: string) {
  const data = ref<T | null>();

  const fetchData = async (): Promise<T> => {
    const response = await fetch<T>(url);
    data.value = response;
    return response;
  };

  onMounted(fetchData);

  return { data };
}
