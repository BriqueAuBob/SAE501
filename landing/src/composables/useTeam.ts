import useFetch from "./useFetch";

export default function useNews() {
  const { data } = useFetch<any[]>("/members");

  return { data };
}
