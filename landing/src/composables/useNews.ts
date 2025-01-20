import useFetch from "./useFetch";
import type { News } from "@/types/news";

export default function useNews() {
  const { data } = useFetch<News[]>("/news");

  return { data };
}
