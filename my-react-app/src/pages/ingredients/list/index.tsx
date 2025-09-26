import React, { useEffect, useState } from "react";
import EnvConfig from "../../../config/env";
import { IngredientItem } from "../types";

const IngredientsList: React.FC = () => {
    const [items, setItems] = useState<IngredientItem[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>("");

    useEffect(() => {
        const controller = new AbortController();
        const load = async () => {
            try {
                const url = `${EnvConfig.API_URL}/api/ingredients`;
                const res = await fetch(url, { signal: controller.signal });
                if (!res.ok) throw new Error(`HTTP ${res.status}`);
                const data: IngredientItem[] = await res.json();
                setItems(data);
            } catch (e: any) {
                if (e.name !== "AbortError") {
                    setError(e.message || "Сталася помилка при завантаженні");
                }
            } finally {
                setLoading(false);
            }
        };
        load();
        return () => controller.abort();
    }, []);

    if (loading) {
        return <div>Завантаження...</div>;
    }

    if (error) {
        return <div className="text-red-600">{error}</div>;
    }

    return (
        <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-6 gap-4">
            {items.map((it) => (
                <div key={it.id} className="bg-white dark:bg-neutral-800 rounded-lg shadow border border-black/10 dark:border-white/10 overflow-hidden">
                    <div className="aspect-square bg-neutral-100 dark:bg-neutral-700">
                        {it.image ? (
                            <img
                                src={`${EnvConfig.API_URL}/${it.image}`}
                                alt={it.name}
                                className="w-full h-full object-cover"
                                loading="lazy"
                            />
                        ) : (
                            <div className="w-full h-full flex items-center justify-center text-neutral-400">Без зображення</div>
                        )}
                    </div>
                    <div className="p-2 text-sm font-medium text-neutral-800 dark:text-neutral-100 truncate" title={it.name}>
                        {it.name}
                    </div>
                </div>
            ))}
        </div>
    );
};

export default IngredientsList;


