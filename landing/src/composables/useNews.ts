import useFetch from "./useFEtch";

type News = {
  title: string;
  description: string;
  content: string;
  date: string;
};

export default function useNews() {
  const { data } = useFetch<News[]>("/news");

  return { data };
}
