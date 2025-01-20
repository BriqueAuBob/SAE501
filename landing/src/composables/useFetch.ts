import fetch from "@/utils/fetch";
import { onMounted } from "vue";

export default function useFetch<T>() {
  const fetchData = async (url: string): Promise<T> => {
    const response = await fetch<T>(url);
    return response;
  };

  onMounted(fetchData);

  return fetchData;
}
