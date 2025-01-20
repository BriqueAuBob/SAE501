import useFetch from "../utils/fetch";

type News = {
  title: string;
  description: string;
  content: string;
  publishedAt: string;
};

export default function useNews() {
  const data = useFetch<News[]>("/news");

  return { data };
}
